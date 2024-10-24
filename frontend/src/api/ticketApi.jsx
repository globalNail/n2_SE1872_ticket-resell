import axiosClient from "./axiosClient";

const ticketApi = {
    getAllTickets: () => {
        const url = "/Ticket/GetAll";
        return axiosClient.get(url);
    },
    getTicketById: (id) => {
        const url = `/Ticket/${id}`;
        return axiosClient.get(url);
    },
    createTicket: (ticketData, formData) => {
        const url = `/Ticket?Barcode=${ticketData.Barcode}&Price=${ticketData.Price}&Quantity=${ticketData.Quantity}&SeatNumber=${ticketData.SeatNumber}&StartDate=${ticketData.StartDate}&categoryName=${ticketData.categoryName}&Description=${ticketData.Description}`
        return axiosClient.post(url, formData, {
            headers: {
                "Content-Type": "multipart/form-data",
            },
        });
    },
    updateTicket: async (id, ticket) => {
        await api.put(`/Ticket/${id}`, ticket);
    },
};

export default ticketApi;
