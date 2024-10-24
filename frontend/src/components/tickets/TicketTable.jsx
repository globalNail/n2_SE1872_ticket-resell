import React from "react";
import { Link } from "react-router-dom";

const TicketTable = ({ tickets }) => {
    return (
        <div className="overflow-x-auto">
            <table className="min-w-full bg-white shadow-md rounded-lg overflow-hidden">
                <tbody>
                    {tickets.map((ticket) => {
                        // Convert StartDate to a readable string with date and time
                        const startDate = new Date(ticket.startDate).toLocaleString('en-US', {
                            weekday: 'short', // Show the day (e.g., Mon)
                            year: 'numeric', // Show the full year
                            month: 'short', // Show the month (e.g., Oct)
                            day: 'numeric', // Show the day of the month
                            hour: 'numeric', // Show hours
                            minute: 'numeric', // Show minutes
                            hour12: true, // 12-hour format with AM/PM
                        });
                        
                        return (
                            <tr key={ticket.ticketId} className="border-b hover:bg-gray-100">
                                {/* StartDate display on the left */}
                                <td className="py-4 px-6 text-center">
                                    <div className="font-bold text-black-600">{startDate}</div>
                                    {/* SellerID */}
                                    <div className="text-gray-400 text-sm mt-2">Seller: {ticket.sellerName|| "N/A"}</div>
                                </td>
                                
                                {/* Event info and Tickets button */}
                                <td className="py-4 px-6 flex justify-between items-center">
                                    <div>
                                        <div className="font-bold text-lg">{ticket.eventName || "Event Name"}</div>
                                        <div className="text-gray-500">{ticket.venue || "Venue"} - {ticket.location || "Location"}</div>
                                    </div>
                                    <div className="text-right">
                                        <Link to={`/tickets/${ticket.TicketId}`} className="bg-yellow-400 text-black font-bold py-2 px-4 rounded hover:bg-yellow-500">
                                            Tickets
                                        </Link>
                                        {/* Ticket price */}
                                        <div className="font-bold text-gray-700 mt-2">
                                            ${typeof ticket.price === "number" ? ticket.price.toFixed(2) : "N/A"}
                                        </div>
                                        <div className="text-red-500 text-xs mt-2">Limited seats available!</div>
                                    </div>
                                </td>
                            </tr>
                        );
                    })}
                </tbody>
            </table>
        </div>
    );
};

export default TicketTable;
