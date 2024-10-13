import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { getTicketById } from "../services/TicketApi";

export default function TicketDetails() {
    const { id } = useParams();
    const [ticket, setTicket] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchTicket = async () => {
            try {
                if (id) {
                    const data = await getTicketById(Number(id));
                    console.log("Fetched Ticket:", data); // Debugging
                    setTicket(data);
                }
            } catch (err) {
                setError("Failed to fetch ticket details.");
                console.error("Error fetching ticket:", err);
            } finally {
                setLoading(false);
            }
        };

        fetchTicket();
    }, [id]);

    const handleAddToCart = () => {
        // You can add cart logic here, e.g., update cart state or call a cart service
        alert(`Ticket "${ticket.barcode}" has been added to your cart!`);
    };

    if (loading) {
        return (
            <div className="container mx-auto p-6">
                Loading ticket details...
            </div>
        );
    }

    if (error) {
        return (
            <div className="container mx-auto p-6 text-red-500">{error}</div>
        );
    }

    if (!ticket) {
        return <div className="container mx-auto p-6">Ticket not found.</div>;
    }

    return (
        <div className="container mx-auto p-6 border rounded shadow-lg bg-white">
            <h1 className="text-3xl font-bold mb-4">{ticket.barcode}</h1>
            <p className="text-lg text-gray-700 mb-2">
                Price: ${ticket.price.toFixed(2)}
            </p>
            <p className="text-lg text-gray-700 mb-2">
                Quantity Available: {ticket.quantity}
            </p>
            <p className="text-lg text-gray-700 mb-2">Status: {ticket.status}</p>
            <p className="text-lg text-gray-700 mb-4">
                Seller ID: {ticket.sellerId}
            </p>
            <p className="text-lg text-gray-700 mb-4">
                Category: {ticket.categoryId}
            </p>
            {/* Add more fields as necessary */}

            <button
                className="mt-4 bg-green-500 text-white py-2 px-4 rounded hover:bg-green-600"
                onClick={handleAddToCart}
            >
                Add to Cart
            </button>
        </div>
    );
}
