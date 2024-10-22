// src/pages/Tickets/ViewTicketPage.jsx
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import ticketApi from "../../api/ticketApi";

const ViewTicketPage = () => {
    const { id } = useParams();
    const [ticket, setTicket] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchTicket = async () => {
            try {
                const response = await ticketApi.getTicketById(id);
                setTicket(response.data);
            } catch (err) {
                setError(
                    err.response?.data?.message || "Error fetching ticket"
                );
            } finally {
                setLoading(false);
            }
        };

        fetchTicket();
    }, [id]);

    if (loading) {
        return (
            <div className="flex justify-center items-center h-screen">
                <div className="text-xl">Loading ticket details...</div>
            </div>
        );
    }

    if (error) {
        return (
            <div className="flex justify-center items-center h-screen">
                <div className="text-red-500 text-xl">Error: {error}</div>
            </div>
        );
    }

    if (!ticket) {
        return (
            <div className="flex justify-center items-center h-screen">
                <div className="text-gray-500 text-xl">Ticket not found.</div>
            </div>
        );
    }

    return (
        <div>
            <h1 className="text-3xl font-bold mb-6">Ticket Details</h1>
            <div className="bg-white shadow-md rounded-lg p-6">
                <p>
                    <strong>ID:</strong> {ticket.TicketId}
                </p>
                <p>
                    <strong>Barcode:</strong> {ticket.Barcode}
                </p>
                <p>
                    <strong>Price:</strong> ${ticket.Price.toFixed(2)}
                </p>
                <p>
                    <strong>Quantity:</strong> {ticket.Quantity || "N/A"}
                </p>
                <p>
                    <strong>Seat Number:</strong> {ticket.SeatNumber || "N/A"}
                </p>
                <p>
                    <strong>Start Date:</strong>{" "}
                    {ticket.StartDate
                        ? new Date(ticket.StartDate).toLocaleString()
                        : "N/A"}
                </p>
                <p>
                    <strong>Status:</strong>{" "}
                    <span
                        className={`px-2 inline-flex text-xs leading-5 font-semibold rounded-full ${
                            ticket.Status === "Open"
                                ? "bg-green-100 text-green-800"
                                : ticket.Status === "Closed"
                                ? "bg-red-100 text-red-800"
                                : "bg-yellow-100 text-yellow-800"
                        }`}
                    >
                        {ticket.Status || "N/A"}
                    </span>
                </p>
                <p>
                    <strong>Description:</strong> {ticket.Description || "N/A"}
                </p>
                {/* Hiển thị các thông tin khác nếu cần */}
                {ticket.PdfFile && (
                    <p>
                        <strong>PDF File:</strong>{" "}
                        <a
                            href={ticket.PdfFile}
                            target="_blank"
                            rel="noopener noreferrer"
                            className="text-blue-500 hover:underline"
                        >
                            Download PDF
                        </a>
                    </p>
                )}
            </div>
        </div>
    );
};

export default ViewTicketPage;
