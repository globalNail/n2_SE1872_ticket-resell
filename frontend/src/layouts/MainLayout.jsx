import React from "react";
import { Outlet, Link } from "react-router-dom";

const MainLayout = () => {
    return (
        <div className="min-h-screen bg-gray-100">
            {/* Navigation Bar */}
            <nav className="bg-white shadow">
                <div className="container mx-auto px-4 py-4 flex justify-between items-center">
                    <Link to="/" className="text-xl font-bold text-blue-500">
                        TicketApp
                    </Link>
                    <div>
                        <Link
                            to="/tickets"
                            className="mr-4 text-gray-700 hover:text-blue-500"
                        >
                            All Tickets
                        </Link>
                        <Link
                            to="/categories"
                            className="mr-4 text-gray-700 hover:text-blue-500"
                        >
                            Categories
                        </Link>
                        <Link
                            to="/tickets/upload"
                            className="text-gray-700 hover:text-blue-500"
                        >
                            Upload Ticket
                        </Link>
                    </div>
                </div>
            </nav>

            {/* Main Content */}
            <div className="container mx-auto px-4 py-8">
                <Outlet />
            </div>
        </div>
    );
};

export default MainLayout;
