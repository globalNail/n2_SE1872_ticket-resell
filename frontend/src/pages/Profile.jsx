import React, { useState, useEffect } from "react";
// Import your user and ticket API functions here

function Profile() {
    const [user, setUser] = useState(null);
    const [tickets, setTickets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchProfileData = async () => {
            try {
                // Replace with your actual API calls
                // const userData = await getUserProfile();
                // const userTickets = await getUserTickets();
                // setUser(userData);
                // setTickets(userTickets);

                // Mock data for demonstration
                setUser({ email: "user@example.com" });
                setTickets([
                    {
                        ticketId: 1,
                        barcode: "ABC123456",
                        price: 50,
                        quantity: 2,
                        status: "verified",
                    },
                    // ... more tickets
                ]);
            } catch (err) {
                setError("Failed to fetch profile data.");
                console.error("Error fetching profile data:", err);
            } finally {
                setLoading(false);
            }
        };

        fetchProfileData();
    }, []);

    if (loading) {
        return <div className="container mx-auto p-6">Loading profile...</div>;
    }

    if (error) {
        return (
            <div className="container mx-auto p-6 text-red-500">{error}</div>
        );
    }

    return (
        <div className="container mx-auto p-6">
            <h1 className="text-3xl font-bold mb-6">My Profile</h1>
            {user && (
                <div className="mb-6">
                    <p>
                        <strong>Email:</strong> {user.email}
                    </p>
                    {/* Add more user details as needed */}
                </div>
            )}

            <h2 className="text-2xl font-semibold mb-4">My Listings</h2>
            {tickets.length === 0 ? (
                <p>You have no listed tickets.</p>
            ) : (
                <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                    {tickets.map((ticket) => (
                        <div
                            key={ticket.ticketId}
                            className="border rounded shadow p-4"
                        >
                            <h3 className="text-xl font-bold mb-2">
                                {ticket.barcode}
                            </h3>
                            <p className="text-gray-700">
                                Price: ${ticket.price.toFixed(2)}
                            </p>
                            <p className="text-gray-700">
                                Quantity: {ticket.quantity}
                            </p>
                            <p className="text-gray-700">
                                Status: {ticket.status}
                            </p>
                            {/* Add actions like Edit or Delete */}
                            <button className="mt-2 bg-red-500 text-white px-4 py-2 rounded hover:bg-red-600">
                                Delete
                            </button>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
}

export default Profile;
