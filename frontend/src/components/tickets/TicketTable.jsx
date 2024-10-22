import React from "react";
import { Link } from "react-router-dom";

const TicketTable = ({ tickets }) => {
    return (
        <div className="overflow-x-auto">
            <table className="min-w-full bg-white shadow-md rounded-lg overflow-hidden">
                <thead className="bg-gray-200">
                    <tr>
                        <th className="py-3 px-6 text-left">ID</th>
                        <th className="py-3 px-6 text-left">Barcode</th>
                        <th className="py-3 px-6 text-left">Price</th>
                        <th className="py-3 px-6 text-left">Quantity</th>
                        <th className="py-3 px-6 text-left">Seat Number</th>
                        <th className="py-3 px-6 text-left">Start Date</th>
                        <th className="py-3 px-6 text-left">Status</th>
                        <th className="py-3 px-6 text-left">Actions</th>
                        {/* Add more columns as needed */}
                    </tr>
                </thead>
                <tbody>
                    {tickets.map((ticket) => (
                        <tr
                            key={ticket.ticketId}
                            className="border-b hover:bg-gray-100"
                        >
                            <td className="py-4 px-6">{ticket.ticketId}</td>
                            <td className="py-4 px-6">{ticket.Barcode}</td>
                            <td className="py-4 px-6">
                                {typeof ticket.Price === "number"
                                    ? ticket.Price.toFixed(2)
                                    : "N/A"}{" "}
                            </td>
                            <td className="py-4 px-6">
                                {ticket.Quantity || "N/A"}
                            </td>
                            <td className="py-4 px-6">
                                {ticket.seatNumber || "N/A"}
                            </td>
                            <td className="py-4 px-6">
                                {ticket.StartDate
                                    ? new Date(
                                          ticket.StartDate
                                      ).toLocaleString()
                                    : "N/A"}
                            </td>
                            <td className="py-4 px-6">
                                <span
                                    className={`px-2 inline-flex text-xs leading-5 font-semibold rounded-full ${
                                        ticket.Status === "Verified"
                                            ? "bg-green-100 text-green-800"
                                            : ticket.Status === "Sold"
                                            ? "bg-red-100 text-red-800"
                                            : "bg-yellow-100 text-yellow-800"
                                    }`}
                                >
                                    {ticket.status || "N/A"}
                                </span>
                            </td>
                            <td className="py-4 px-6">
                                <Link
                                    to={`/tickets/${ticket.TicketId}`}
                                    className="text-blue-500 hover:underline"
                                >
                                    View
                                </Link>
                                {/* Bạn có thể thêm các hành động khác như Edit, Delete */}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default TicketTable;
