import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";
import headerLogo from '../images/concert.jpg'; // Background image
import concertImage from '../images/anhtrai.jpg'; // Concert A image
import sportImage from '../images/train.jpg'; // Sport Event B image
import theaterImage from '../images/vba.jpg'; // Theater C image

// Import new category images
import footballImage from '../images/football.jpg';
import tennisImage from '../images/tennis.jpg';
import basketballImage from '../images/basketball.jpg';
import golfImage from '../images/golf.jpg';
import eventImage from '../images/event.jpg';
import comedyImage from '../images/comedy.jpg';
import travelImage from '../images/travel.jpg';
import showImage from '../images/show.jpg';

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

    // Ticket categories
    const ticketCategories = [
        { name: 'Football', link: '/category/football', image: footballImage },
        { name: 'Tennis', link: '/category/tennis', image: tennisImage },
        { name: 'Basketball', link: '/category/basketball', image: basketballImage },
        { name: 'Golf', link: '/category/golf', image: golfImage },
        { name: 'Event', link: '/category/event', image: eventImage },
        { name: 'Comedy', link: '/category/comedy', image: comedyImage },
        { name: 'Travel', link: '/category/travel', image: travelImage },
        { name: 'Shows', link: '/category/shows', image: showImage },
    ];

    // State to track the current set of categories being displayed
    const [currentIndex, setCurrentIndex] = useState(0);

    // Function to handle the next button click
    const handleNextClick = () => {
        setCurrentIndex((prevIndex) => {
            const newIndex = prevIndex + 3;
            // If new index exceeds total categories, show remaining categories or loop back
            return newIndex >= ticketCategories.length ? 0 : newIndex;
        });
    };

    // Determine the categories to display based on currentIndex
    const categoriesToDisplay = ticketCategories.slice(currentIndex, currentIndex + 3);

    return (
        
         
        <div className="relative">
            {/* Main Container */}
            <div className="relative w-full h-screen">
                {/* Background Image */}
                <div
                    className="absolute top-0 left-0 w-full h-full bg-no-repeat bg-cover bg-center"
                    style={{ backgroundImage: `url(${headerLogo})` }}
                ></div>

                {/* Sell Tickets Button */}
                <button
                    className="absolute top-20 right-10 mt-6 bg-blue-600 text-white px-6 py-3 rounded hover:bg-blue-700 z-10"
                    onClick={handleSellTicket}
                >
                    Sell Tickets
                </button>

                {/* Search Bar */}
                <div className="absolute top-1/4 left-1/2 transform -translate-x-1/2 -translate-y-1/2 z-10 text-center">
                <h1 style={{ animation: "blink 1s infinite" }} className="text-4xl font-bold mb-4 text-white">
  Welcome to TicketResell
</h1>
                    <p className="text-lg text-white">Buy and sell tickets for your favorite events with ease.</p>
                </div>

                <div className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 z-10">
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

            {/* Seller Ratings */}
            <section className="mt-12">
                <h2 className="text-2xl font-semibold mb-4">Top Rated Sellers</h2>
                <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                    <div className="flex items-center">
                        <div className="ml-4">
                            <h3 className="text-lg font-bold">Pham Quoc Dat</h3>
                            <p className="text-yellow-500">★★★★★</p>
                            <p className="text-gray-500">Best Rated</p>
                        </div>
                    </div>
                    <div className="flex items-center">
                        <div className="ml-4">
                            <h3 className="text-lg font-bold">Vu Minh Thao</h3>
                            <p className="text-yellow-500">★★★★☆</p>
                            <p className="text-gray-500">Above Average</p>
                        </div>
                    </div>
                    <div className="flex items-center">
                        <div className="ml-4">
                            <h3 className="text-lg font-bold">Truong Thao My</h3>
                            <p className="text-yellow-500">★★★☆☆</p>
                            <p className="text-gray-500">Average</p>
                        </div>
                    </div>
                </div>
            </section>

            {/* Ticket Categories Section */}
            <section className="mt-12">
                <h2 className="text-2xl font-semibold mb-4">Ticket Categories</h2>
                <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                    {categoriesToDisplay.map((category, index) => (
                        <div key={index} className="group border rounded shadow p-4 h-60 overflow-hidden">
                            <h3 className="text-xl font-bold">{category.name}</h3>
                            <img src={category.image} alt={category.name} className="w-full h-48 object-cover transform transition-transform duration-300 group-hover:scale-110" />
                            <Link to={category.link}>
                                <button className="mt-2 text-white px-4 py-2 rounded hover:bg-green-600">
                                    {category.name}
                                </button>
                            </Link>
                        </div>
                    ))}
                </div>
                <div className="text-right mt-4">
                    <button
                        className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
                        onClick={handleNextClick}
                    >
                         →
                    </button>
                </div>
            </section>

           {/* Featured Tickets Section */}
           <section>
                <h2 className="text-2xl font-semibold mb-4">Featured Tickets</h2>
                <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                    <div className="group border rounded shadow p-4 h-65">
                        <h3 className="text-xl font-bold">Concert Anh Trai "Say Hi"</h3>
                        <div className="overflow-hidden">
                            <img
                                src={concertImage}
                                alt="Concert A"
                                className="w-full h-48 object-cover transform transition-transform duration-300 group-hover:scale-110"
                            />
                        </div>
                        <p>Price: $50</p>
                        <p>Date: 2024-05-20</p>
                        <Link to="/tickets/1">
                            <button className="mt-2 bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600">
                                View Details
                            </button>
                        </Link>
                    </div>
                    <div className="group border rounded shadow p-4 h-65">
                        <h3 className="text-xl font-bold">Tàu Bắc Nam</h3>
                        <div className="overflow-hidden">
                            <img
                                src={sportImage}
                                alt="Sports Event B"
                                className="w-full h-48 object-cover transform transition-transform duration-300 group-hover:scale-110"
                            />
                        </div>
                        <p>Price: $75</p>
                        <p>Date: 2024-06-15</p>
                        <Link to="/tickets/2">
                            <button className="mt-2 bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600">
                                View Details
                            </button>
                        </Link>
                    </div>
                    <div className="group border rounded shadow p-4 h-65">
                        <h3 className="text-xl font-bold">VBA</h3>
                        <div className="overflow-hidden">
                            <img
                                src={theaterImage}
                                alt="Theater C"
                                className="w-full h-48 object-cover transform transition-transform duration-300 group-hover:scale-110"
                            />
                        </div>
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
             {/* Footer Section */}
             <footer className="bg-gray-800 text-white py-10 mt-20">
    <div className="container mx-auto text-center">
        <p className="mb-2">© 2024 TicketResell. All rights reserved.</p>
        <div className="flex justify-center space-x-6">
            <Link to="/about" className="hover:underline">About Us</Link>
            <Link to="/contact" className="hover:underline">Contact</Link>
            <Link to="/privacy" className="hover:underline">Privacy Policy</Link>
            <Link to="/terms" className="hover:underline">Terms of Service</Link>
        </div>
    </div>
</footer>
        </div>
    );
}

export default Home;
