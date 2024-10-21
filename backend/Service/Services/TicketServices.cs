using Google.Cloud.Storage.V1;
using Repository.DTOs.Ticket;
using Repository.Interfaces;
using Repository.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TicketServices : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ICategoryyRepository _categoryRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly string _projectId = "ticketresellauth";
        private readonly string _bucketName = "ticketresellauth.appspot.com";
        public TicketServices(ITicketRepository ticketRepository, ICategoryyRepository categoryyRepository, IMemberRepository memberRepository, IStaffRepository staffRepository)
        {
            _ticketRepository = ticketRepository;
            _categoryRepository = categoryyRepository;
            _memberRepository = memberRepository;
            _staffRepository = staffRepository;
        }

        #region Add Ticket
        public async Task<string> AddTicket(TicketDtos ticketDtos)
        {
            if (ticketDtos == null)
            {
                return "Data is null";
            }
            if (ticketDtos == null)
            {
                return "Data is null";
            }
            if (ticketDtos.File == null || ticketDtos.File.Length == 0)
            {
                return "File không hợp lệ";
            }
            // Check the file extension
            var allowedExtensions = new[] { ".jpg", ".jpeg", "png" }; // Define allowed extensions
            var fileExtension = Path.GetExtension(ticketDtos.File.FileName).ToLowerInvariant(); // Get the file extension

            if (!allowedExtensions.Contains(fileExtension))
            {
                return "File phải có định dạng .jpg hoặc .jpeg";
            }
            using (var memoryStream = new MemoryStream())
            {
                await ticketDtos.File.CopyToAsync(memoryStream);
                var bytes = memoryStream.ToArray();

                // Initialize Firebase Admin SDK
                var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile("TicketResell.json");
                //tạm thời hardcode, thay sau FromFile thành đường dẫn file net1701-jewelry...
                var storage = StorageClient.Create(credential);

                // Construct the object name (path) in Firebase Storage
                var objectName = $"images/{DateTime.Now.Ticks}_{ticketDtos.File.FileName}";

                // Upload the file to Firebase Storage
                var response = await storage.UploadObjectAsync(
                    bucket: _bucketName,
                    objectName: objectName,
                    contentType: ticketDtos.File.ContentType,
                    source: new MemoryStream(bytes)
                );
                // Tải file lên Firebase Storage
                //var storageObject = await storage.GetObjectAsync(_bucketName, objectName);
                var downloadUrl = /*storageObject.MediaLink*/ $"https://storage.googleapis.com/{_bucketName}/{objectName}";
                Ticket ticket = new Ticket()
                {
                    Barcode = ticketDtos.Barcode,
                    Price = ticketDtos.Price,
                    Quantity = ticketDtos.Quantity,
                    SeatNumber = ticketDtos.SeatNumber,
                    SellerId = ticketDtos.SellerId,
                    CategoryId = ticketDtos.CategoryId,
                    PdfFile = downloadUrl,
                    Status = "Pending",
                    PostedAt = DateTime.Now,
                    StartDate = DateTime.Now,
                    ApprovedBy = null,
                    ApprovalDate = null,
                    Description = ticketDtos.Description,
                    ModifiedDate = null
                };
                var result = await _ticketRepository.AddTicket(ticket);
                return result ? "Add Successful" : "Add failed";
            }
        }

        #endregion
        public async Task<int> CountTicket()
        {
           return await _ticketRepository.CountTicket();
        }

        public async Task DeleteTicket(int ticketId)
        {
            try
            {
                if (ticketId == null)
                {
                    throw new Exception("please enter ticketId");
                }
                await _ticketRepository.DeleteTicket(ticketId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region GetAll Ticket
        public async Task<List<TicketResponse>> GetAllTicket()
        {
            try
            {


                List<TicketResponse> ticketResponse = new List<TicketResponse>();
                var listTicket = await _ticketRepository.GetAllTickets();
                {
                    foreach (var item in listTicket)
                    {
                        var ticket = await _ticketRepository.GetTicketsById(item.TicketId);
                        if (ticket == null)
                        {
                            throw new Exception($"ticket not found");
                        }
                        var category = await _categoryRepository.GetCategoryById(ticket.CategoryId);
                        if (category == null)
                        {
                            throw new Exception($"category not found");
                        }
                        var member = await _memberRepository.GetMember(ticket.SellerId);
                        if (member == null)
                        {
                            throw new Exception($"member not found");
                        }
                        var staff = await _staffRepository.GetStaffById(ticket.ApprovedBy);
                        if (item.Quantity > 0 && item.Status == "Verified")
                        {
                            var newTicket = new TicketResponse()
                            {
                                TicketId = item.TicketId,
                                Barcode = item.Barcode,
                                Quantity = item.Quantity,
                                Price = item.Price,
                                SeatNumber = item.SeatNumber,
                                StartDate = item.StartDate,
                                SellerName = member?.User?.Username ?? "Unknown",
                                CategoryName = category.CategoryName,
                                PdfFile = item.PdfFile,
                                Status = item.Status,
                                PostedAt = item.PostedAt,
                                ApprovedBy = staff?.User?.Username ?? "Unknown", 
                                ApprovalDate = item.ApprovalDate,
                                Description = item.Description,
                                ModifiedDate = item.ModifiedDate,

                            };
                            ticketResponse.Add(newTicket);
                        }
                    }
                    return ticketResponse;
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get Ticket
        public async Task<TicketResponse> GetTicketById(int ticketId)
        {
            var ticket = await _ticketRepository.GetTicketsById(ticketId);
            if(ticket == null)
            {
                throw new Exception($"Ticket {ticketId} not found");
            }
            var category = await _categoryRepository.GetCategoryById(ticket.CategoryId);
            if (category == null)
            {
                throw new Exception("category not found");
            }
            var member = await _memberRepository.GetMember(ticket.SellerId);
            if (member == null)
            {
                throw new Exception("member not found");
            }
            var staff = await _staffRepository.GetStaffById(ticket.ApprovedBy);
            var ticketResponse = new TicketResponse()
            {
                TicketId = ticket.TicketId,
                Barcode = ticket.Barcode,
                Quantity = ticket.Quantity,
                Price = ticket.Price,
                SeatNumber = ticket.SeatNumber,
                StartDate = ticket.StartDate,                
                SellerName = member?.User?.Username ?? "Unknown",
                CategoryName = category.CategoryName,
                PdfFile = ticket.PdfFile,
                Status = ticket.Status,
                PostedAt = ticket.PostedAt,
                ApprovedBy = staff?.User?.Username ?? "Unknown",
                ApprovalDate = ticket.ApprovalDate,
                 Description= ticket.Description,
                ModifiedDate = ticket.ModifiedDate,
            };
            return ticketResponse;
        }
        #endregion

        public async Task<string> UpdateTicket(int ticketId, TicketUpdatedtos ticketUpdatedtos)
        {
            if (ticketId == null || ticketId == 0)
            {
                return "Please enter ticketId";
            }
            if(ticketUpdatedtos == null)
            {
                return "Data is null";
            }
           var existingTicket = await _ticketRepository.GetTicketsById(ticketId);
            if (existingTicket == null)
            {
                return "ticket not found";
            }
            existingTicket.Quantity = ticketUpdatedtos.Quantity;
            existingTicket.Price = ticketUpdatedtos.Price;
            existingTicket.SeatNumber = ticketUpdatedtos.SeatNumber;
            existingTicket.Description = ticketUpdatedtos.Description;
            existingTicket.ModifiedDate = DateTime.Now;
            var result = await _ticketRepository.UpdateTicket(existingTicket);
            return result ? "Update Successfull" : "Update failed";
        }

        public async Task<string> UpdateTicketForStaff(int ticketId, TicketStaffDtos ticketUpdatedtos)
        {

            if (ticketId == null || ticketId == 0)
            {
                return "Please enter ticketId";
            }
            if (ticketUpdatedtos == null)
            {
                return "Data is null";
            }
            var existingTicket = await _ticketRepository.GetTicketsById(ticketId);
            if (existingTicket == null)
            {
                return "ticket not found";
            }
            existingTicket.Status = ticketUpdatedtos.Status;
            existingTicket.ApprovedBy = ticketUpdatedtos.ApprovedBy;
            existingTicket.ApprovalDate = DateTime.Now;
            var result = await _ticketRepository.UpdateTicket(existingTicket);
            return result ? "Update Successfull" : "Update failed";

        }
    }
}
