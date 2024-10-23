import React from "react";
import useFetchTickets from "../../hooks/useFetchTickets";
import TicketTable from "../../components/tickets/TicketTable";
import { Link } from "react-router-dom";

const TicketsPage = () => {
    const { tickets, loading, error } = useFetchTickets();

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
        <div>
            <div className="flex justify-between items-center mb-6">
                <h1 className="text-3xl font-bold">All Tickets</h1>
                <Link
                    to="/tickets/upload"
                    
                >
                 
                </Link>
            </div>
            {tickets.length === 0 ? (
                <div className="text-gray-500">No tickets available.</div>
            ) : (
                <TicketTable tickets={tickets} />
            )}
        </div>
    );
};

export default TicketsPage;
