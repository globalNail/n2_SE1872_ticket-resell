import React, { useEffect, useState } from "react";
import ticketApi from "../../api/ticket";

const TicketsPage = () => {
    const [tickets, setTickets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchTickets = async () => {
            try {
                const response = await ticketApi.getAllTickets();
                setTickets(response.data);
            } catch (err) {
                setError(err.message || "Error fetching tickets");
            } finally {
                setLoading(false);
            }
        };

        fetchTickets();
    }, []);

    if (loading) {
        return (
            <div className="flex justify-center items-center h-screen">
                <div className="text-xl">Loading tickets...</div>
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

    return (
        <div className="container mx-auto px-4 py-8">
            <h1 className="text-3xl font-bold mb-6">All Tickets</h1>
            {tickets.length === 0 ? (
                <div className="text-gray-500">No tickets available.</div>
            ) : (
                <div className="overflow-x-auto">
                    <table className="min-w-full bg-white shadow-md rounded-lg overflow-hidden">
                        <thead className="bg-gray-200">
                            <tr>
                                <th className="py-3 px-6 text-left">ID</th>
                                <th className="py-3 px-6 text-left">seat</th>
                                <th className="py-3 px-6 text-left">
                                    Description
                                </th>
                                <th className="py-3 px-6 text-left">Status</th>
                                {/* Add more columns as needed */}
                            </tr>
                        </thead>
                        <tbody>
                            {tickets.map((ticket) => (
                                <tr
                                    key={ticket.ticketId}
                                    className="border-b hover:bg-gray-100"
                                >
                                    <td className="py-4 px-6">
                                        {ticket.ticketId}
                                    </td>
                                    <td className="py-4 px-6">
                                        {ticket.seatNumber}
                                    </td>
                                    <td className="py-4 px-6">
                                        {ticket.description}
                                    </td>
                                    <td className="py-4 px-6">
                                        <span
                                            className={`px-2 inline-flex text-xs leading-5 font-semibold rounded-full ${
                                                ticket.status === "Open"
                                                    ? "bg-green-100 text-green-800"
                                                    : ticket.status === "Closed"
                                                    ? "bg-red-100 text-red-800"
                                                    : "bg-yellow-100 text-yellow-800"
                                            }`}
                                        >
                                            {ticket.status}
                                        </span>
                                    </td>
                                    {/* Add more fields as needed */}
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            )}
        </div>
    );
};

export default TicketsPage;
