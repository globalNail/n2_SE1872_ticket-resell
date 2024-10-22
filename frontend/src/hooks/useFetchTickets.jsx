import { useState, useEffect } from "react";
import ticketApi from "../api/ticketApi";

const useFetchTickets = () => {
    const [tickets, setTickets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchTickets = async () => {
            try {
                const response = await ticketApi.getAllTickets();
                console.log(response.data);
                const validatedTickets = response.data.map((ticket) => ({
                    ...ticket,
                    Price: typeof ticket.Price === "number" ? ticket.Price : 0,
                }));
                setTickets(validatedTickets);
            } catch (err) {
                setError(
                    err.response?.data?.message || "Error fetching tickets"
                );
            } finally {
                setLoading(false);
            }
        };

        fetchTickets();
    }, []);

    return { tickets, loading, error };
};

export default useFetchTickets;
