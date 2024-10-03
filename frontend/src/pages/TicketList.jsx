import React, { useState, useEffect } from "react";
import { getAllTickets } from "../services/TicketApi";
import TicketCard from "../componets/ticket/TicketCard";

const TicketListPage = () => {
    const [tickets, setTickets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchTickets = async () => {
            try {
                const data = await getAllTickets();
                console.log("Fetched Tickets:", data); // Debugging
                setTickets(data);
            } catch (err) {
                setError("Failed to fetch tickets.");
                console.error("Error fetching tickets:", err);
            } finally {
                setLoading(false);
            }
        };

        fetchTickets();
    }, []);

    return (
        <div className="container mx-auto p-6">
            <h1 className="text-3xl font-bold mb-6">Available Tickets</h1>

            {loading && <div>Loading tickets...</div>}
            {error && <div className="text-red-500 mb-4">{error}</div>}

            <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                {tickets.map((ticket) => (
                    <TicketCard key={ticket.ticketId} ticket={ticket} />
                ))}
            </div>
        </div>
    );
};

export default TicketListPage;
