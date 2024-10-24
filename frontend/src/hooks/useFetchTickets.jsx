import { useState, useEffect } from "react"; 
import ticketApi from "../api/ticketApi";

const useFetchTickets = () => {
    const [tickets, setTickets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchTickets = async () => {
            setLoading(true); // Ensure loading state is set to true when fetching starts

            try {
                const response = await ticketApi.getAllTickets();
                
                console.log(response.data); // Log the entire response to inspect it

                // Validate and ensure 'Price' is a number, setting default value if not
                const validatedTickets = response.data.map((ticket) => ({
                    ...ticket,
                    Price: !isNaN(ticket.Price) ? ticket.Price : 0,
                    // Ensure SellerID is mapped correctly
                    SellerID: ticket.SellerID !== undefined ? ticket.SellerID : "N/A" // Fallback if not found
                }));

                setTickets(validatedTickets);
            } catch (err) {
                console.error("Error fetching tickets:", err);
                setError(err.response?.data?.message || "Error fetching tickets");
            } finally {
                setLoading(false); // Always stop loading after the fetch attempt
            }
        };

        fetchTickets();
    }, []); // Empty dependency array ensures this runs only once when the component is mounted

    return { tickets, loading, error };
};

export default useFetchTickets;
