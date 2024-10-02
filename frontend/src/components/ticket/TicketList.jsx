import React, { useState, useEffect } from "react";
import { getAllTickets } from "../../services/ticketApi";

const TicketList = () => {
    const [tickets, setTickets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchTickets = async () => {
            try {
                const data = await getAllTickets();
                console.log("Fetched Tickets:", data); // Debugging: Log fetched data

                if (!Array.isArray(data)) {
                    throw new Error("Fetched data is not an array.");
                }

                setTickets(data);
            } catch (err) {
                setError(err.message || "Failed to fetch tickets.");
                console.error("Error fetching tickets:", err);
            } finally {
                setLoading(false);
            }
        };

        fetchTickets();
    }, []);

    if (loading) {
        return <div>Loading tickets...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    return (
        <div className="container mx-auto p-4">
            <h1 className="text-2xl font-bold mb-4">Available Tickets</h1>
            {tickets.length === 0 ? (
                <p>No tickets available.</p>
            ) : (
                <ul>
                    {tickets.map((ticket) => (
                        <li
                            key={ticket.ticketId}
                            className="mb-4 p-4 border rounded"
                        >
                            <h3 className="text-lg font-semibold">
                                {ticket.barcode}
                            </h3>
                            <p>Price: ${ticket.price.toFixed(2)}</p>
                            <p>Quantity: {ticket.quantity}</p>
                            <p>Status: {ticket.status}</p>
                            {/* Add more ticket details or actions (e.g., edit, delete) */}
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default TicketList;
