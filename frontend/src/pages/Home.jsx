import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";
import headerLogo from "../assets/images/concert.jpg"; // Background image
import concertImage from "../assets/images/anhtrai.jpg"; // Concert A image
import sportImage from "../assets/images/train.jpg"; // Sport Event B image
import theaterImage from "../assets/images/vba.jpg"; // Theater C image

// Import new category images
import footballImage from "../assets/images/football.jpg";
import tennisImage from "../assets/images/tennis.jpg";
import basketballImage from "../assets/images/basketball.jpg";
import golfImage from "../assets/images/golf.jpg";
import eventImage from "../assets/images/event.jpg";
import comedyImage from "../assets/images/comedy.jpg";
import travelImage from "../assets/images/travel.jpg";
import showImage from "../assets/images/show.jpg";

function Home() {
    // Ticket categories
    const ticketCategories = [
        { name: "Football", link: "/category/football", image: footballImage },
        { name: "Tennis", link: "/category/tennis", image: tennisImage },
        {
            name: "Basketball",
            link: "/category/basketball",
            image: basketballImage,
        },
        { name: "Golf", link: "/category/golf", image: golfImage },
        { name: "Event", link: "/category/event", image: eventImage },
        { name: "Comedy", link: "/category/comedy", image: comedyImage },
        { name: "Travel", link: "/category/travel", image: travelImage },
        { name: "Shows", link: "/category/shows", image: showImage },
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
    const categoriesToDisplay = ticketCategories.slice(
        currentIndex,
        currentIndex + 3
    );

    return (
        <div className="relative">
            {/* Main Container */}
            <div className="relative w-full h-screen">
                {/* Background Image */}
                <div
                    className="absolute top-0 left-0 w-full h-full bg-no-repeat bg-cover bg-center"
                    style={{ backgroundImage: `url(${headerLogo})` }}
                ></div>

                {/* Search Bar */}
                <div className="absolute top-1/4 left-1/2 transform -translate-x-1/2 -translate-y-1/2 z-10 text-center">
                    <h1
                        style={{ animation: "blink 1s infinite" }}
                        className="text-4xl font-bold mb-4 text-white"
                    >
                        Welcome to TicketResell
                    </h1>
                    <p className="text-lg text-white">
                        Buy and sell tickets for your favorite events with ease.
                    </p>
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
                <h2 className="text-2xl font-semibold mb-4">
                    Top Rated Sellers
                </h2>
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
                            <h3 className="text-lg font-bold">
                                Truong Thao My
                            </h3>
                            <p className="text-yellow-500">★★★☆☆</p>
                            <p className="text-gray-500">Average</p>
                        </div>
                    </div>
                </div>
            </section>

            {/* Ticket Categories Section */}
            <section className="mt-12 relative">
                <h2 className="text-2xl font-semibold mb-4">Ticket Categories</h2>
                <div className="grid grid-cols-1 md:grid-cols-3 gap-6 relative">
                    {categoriesToDisplay.map((category, index) => (
                        <div
                            key={index}
                            className="group relative border rounded shadow h-60 overflow-hidden"
                        >
                            {/* Hình ảnh */}
                            <img
                                src={category.image}
                                alt={category.name}
                                className="w-full h-full object-cover transition-transform duration-300 transform group-hover:scale-110"
                            />
                            {/* Tên Category hiển thị trên hình */}
                            <h3 className="absolute inset-0 flex items-center justify-center bg-black bg-opacity-50 text-white text-xl font-bold opacity-0 group-hover:opacity-100 transition-opacity duration-300">
                                {category.name}
                            </h3>
                            {/* Nút */}
                            <Link to={category.link} className="absolute bottom-4 right-4">
                                <button className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600">
                                    {category.name}
                                </button>
                            </Link>
                        </div>
                    ))}
                </div>
                {/* Nút mũi tên */}
                <button
                    className="arrow-button absolute top-1/2 right-0 transform -translate-y-1/2  text-white px-4 py-2 rounded hover: transition-all duration-300 group-hover:translate-x-2"
                    onClick={handleNextClick}
                >
                    →
                </button>
            </section>

            {/* Featured Tickets Section */}
            <section className="mt-12 mb-0 flex-grow">
                <h2 className="text-2xl font-semibold mb-4">Featured Tickets</h2>
                <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                    {[
                        { name: "Concert Anh Trai 'Say Hi'", price: "$50", date: "2024-05-20", image: concertImage, link: "/tickets/1" },
                        { name: "Tàu Bắc Nam", price: "$75", date: "2024-06-15", image: sportImage, link: "/tickets/2" },
                        { name: "VBA", price: "$60", date: "2024-07-10", image: theaterImage, link: "/tickets/3" }
                    ].map((ticket, index) => (
                        <div key={index} className="group relative border rounded shadow h-65 overflow-hidden">
                            <img
                                src={ticket.image}
                                alt={ticket.name}
                                className="w-full h-full object-cover transition-transform duration-300 group-hover:scale-110"
                            />
                            <div className="absolute inset-0 bg-black bg-opacity-50 text-white p-4 flex flex-col justify-between opacity-0 group-hover:opacity-100 transition-opacity duration-300">
                                <div>
                                    <h3 className="text-xl font-bold">{ticket.name}</h3>
                                    <p>Price: {ticket.price}</p>
                                    <p>Date: {ticket.date}</p>
                                </div>
                                <Link to={ticket.link}>
                                    <button className="mt-2 bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600">
                                        View Details
                                    </button>
                                </Link>
                            </div>
                        </div>
                    ))}
                </div>
            </section>

            {/* Footer Section */}
            <footer className="bg-gray-800 text-white py-10 mt-20">
                <div className="container mx-auto text-center">
                    <p className="mb-2">
                        © 2024 TicketResell. All rights reserved.
                    </p>
                    <div className="flex justify-center space-x-6">
                        <Link to="/about" className="hover:underline">
                            About Us
                        </Link>
                        <Link to="/contact" className="hover:underline">
                            Contact
                        </Link>
                        <Link to="/privacy" className="hover:underline">
                            Privacy Policy
                        </Link>
                        <Link to="/terms" className="hover:underline">
                            Terms of Service
                        </Link>
                    </div>
                </div>
            </footer>
        </div>
    );
}

export default Home;
