import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";
import headerLogo from '../images/concert.jpg'; // Import hình ảnh

function Home() {
    const navigate = useNavigate();
    const { currentUser } = useAuth();

    const handleSellTicket = () => {
        if (currentUser) {
            navigate("/up-ticket");
        } else {
            navigate("/signup"); // Redirect to signup/login page if not logged in
        }
    };

    return (
        <div className="container mx-auto p-6 relative">
            {/* Thêm logo và các nút Login, Sign up */}
            <div className="relative">
                {/* Ảnh nền */}
                <img src={headerLogo} alt="Header Logo" className="w-full h-auto" />

                {/* Nút Login và Sign up */}
                <button
                    className="absolute top-20 right-10 mt-6 bg-blue-600 text-white px-6 py-3 rounded hover:bg-blue-700"
                    onClick={handleSellTicket}
                >
                    Sell Tickets
                </button>

                <div className="absolute top-4 right-4 flex space-x-4">
                    <Link to="/login">
                        <button className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700">
                            Login
                        </button>
                    </Link>
                    <Link to="/signup">
                        <button className="bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700">
                            Sign up
                        </button>
                    </Link>
                </div>

                {/* Thanh tìm kiếm */}
                <div className="absolute top-1/4 left-1/2 transform -translate-x-1/2 - translate-y-1/2">
                <h1 className="text-4xl font-bold mb-4 text-white">Welcome to TicketResell</h1>
                <p className="text-lg text-white">Buy and sell tickets for your favorite events with ease.</p>
                </div>
                <div className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2">
                    <input
                        type="text"
                        placeholder="Search tickets..."
                        className="px-4 py-2 rounded-lg border-2 border-gray-300 w-96"
                    />
                    <button className="ml-2 bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700">
                        Search
                    </button>
                </div>
            </div>
               
                 {/* New section for Seller Ratings */}
            <section className="mt-12">
                <h2 className="text-2xl font-semibold mb-4">Top Rated Sellers</h2>
                <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                    <div className="flex items-center">
                        {/* <img
                            src="seller1.png"
                            alt="Pham Quoc Dat"
                            className="w-16 h-16 rounded-full"
                        /> */}
                        <div className="ml-4">
                            <h3 className="text-lg font-bold">Pham Quoc Dat</h3>
                            <p className="text-yellow-500">★★★★★</p>
                            <p className="text-gray-500">Best Rated</p>
                        </div>
                    </div>
                    <div className="flex items-center">
                        {/* <img
                            src="seller2.png"
                            alt="Vu Minh Thao"
                            className="w-16 h-16 rounded-full"
                        /> */}
                        <div className="ml-4">
                            <h3 className="text-lg font-bold">Vu Minh Thao</h3>
                            <p className="text-yellow-500">★★★★☆</p>
                            <p className="text-gray-500">Above Average</p>
                        </div>
                    </div>
                    <div className="flex items-center">
                        {/* <img
                            src="seller3.png"
                            alt="Truong Thao My"
                            className="w-16 h-16 rounded-full"
                        /> */}
                        <div className="ml-4">
                            <h3 className="text-lg font-bold">Truong Thao My</h3>
                            <p className="text-yellow-500">★★★☆☆</p>
                            <p className="text-gray-500">Average</p>
                        </div>
                    </div>
                </div>
            </section>

         
            <section className="text-center mb-12">
                
               
              
                {/* Button for Staff Approval */}
                <Link to="/staff-approval">
                    <button className="mt-6 ml-4 bg-blue-600 text-white px-6 py-3 rounded hover:bg-blue-700">
                        Browse Tickets
                    </button>
                </Link>
            </section>

            <section>
                <h2 className="text-2xl font-semibold mb-4">Featured Tickets</h2>
                <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
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
