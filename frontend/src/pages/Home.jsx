import React from "react";
import { Link } from "react-router-dom";

function Home() {
    return (
        <div className="container mx-auto p-6">
            <section className="text-center mb-12">
                <h1 className="text-4xl font-bold mb-4">
                    Welcome to TicketResell
                </h1>
                <p className="text-lg">
                    Buy and sell tickets for your favorite events with ease.
                </p>
                <Link to="/tickets">
                    <button className="mt-6 bg-blue-600 text-white px-6 py-3 rounded hover:bg-blue-700">
                        Browse Tickets
                    </button>
                </Link>
                <Link to="/UpTicket">
                    <button className="mt-6 bg-blue-600 text-white px-6 py-3 rounded hover:bg-blue-700">
                        Sell Tickets
                    </button>
                </Link>
            </section>

            <section>
                <h2 className="text-2xl font-semibold mb-4">
                    Featured Tickets
                </h2>
                <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                    {/* Replace with dynamic data as needed */}
                    <div className="border rounded shadow p-4">
                        <h3 className="text-xl font-bold">Concert A</h3>
                        <p>Price: $50</p>
                        <p>Date: 2024-05-20</p>
                        <Link to="/tickets/1">
                            <button className="mt-2 bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600">
                                View Details
                            </button>
                        </Link>
                    </div>
                    <div className="border rounded shadow p-4">
                        <h3 className="text-xl font-bold">Sports Event B</h3>
                        <p>Price: $75</p>
                        <p>Date: 2024-06-15</p>
                        <Link to="/tickets/2">
                            <button className="mt-2 bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600">
                                View Details
                            </button>
                        </Link>
                    </div>
                    <div className="border rounded shadow p-4">
                        <h3 className="text-xl font-bold">Theater C</h3>
                        <p>Price: $60</p>
                        <p>Date: 2024-07-10</p>
                        <Link to="/tickets/3">
                            <button className="mt-2 bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600">
                                View Details
                            </button>
                        </Link>
                    </div>
                </div>
            </section>
        </div>
    );
}

export default Home;
