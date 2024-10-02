// src/pages/admin/AdminDashboard.jsx
import React, { useState, useEffect } from "react";
// Import your admin API functions here

function AdminDashboard() {
    const [tickets, setTickets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchAllTickets = async () => {
            try {
                // Replace with your actual admin API call to fetch all tickets
                // const data = await getAllTicketsAdmin();
                // setTickets(data);

                // Mock data for demonstration
                setTickets([
                    {
                        ticketId: 1,
                        barcode: "ABC123456",
                        price: 50,
                        quantity: 2,
                        status: "pending",
                    },
                    // ... more tickets
                ]);
            } catch (err) {
                setError("Failed to fetch tickets.");
                console.error("Error fetching admin tickets:", err);
            } finally {
                setLoading(false);
            }
        };

        fetchAllTickets();
    }, []);

    return (
        <div className="container mx-auto p-6">
            <h1 className="text-3xl font-bold mb-6">Admin Dashboard</h1>

            {loading && <div>Loading tickets...</div>}
            {error && <div className="text-red-500 mb-4">{error}</div>}

            <table className="min-w-full bg-white">
                <thead>
                    <tr>
                        <th className="py-2">Ticket ID</th>
                        <th className="py-2">Barcode</th>
                        <th className="py-2">Price</th>
                        <th className="py-2">Quantity</th>
                        <th className="py-2">Status</th>
                        <th className="py-2">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {tickets.map((ticket) => (
                        <tr key={ticket.ticketId} className="text-center">
                            <td className="py-2 border">{ticket.ticketId}</td>
                            <td className="py-2 border">{ticket.barcode}</td>
                            <td className="py-2 border">
                                ${ticket.price.toFixed(2)}
                            </td>
                            <td className="py-2 border">{ticket.quantity}</td>
                            <td className="py-2 border">{ticket.status}</td>
                            <td className="py-2 border">
                                {/* Add admin actions like Edit or Delete */}
                                <button className="bg-red-500 text-white px-3 py-1 rounded hover:bg-red-600">
                                    Delete
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default AdminDashboard;
