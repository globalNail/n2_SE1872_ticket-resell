// Header.jsx
import React, { useContext } from "react";
import { AuthContext } from "../../contexts/AuthContext";
import { Link, useNavigate } from "react-router-dom";
import { auth } from "../../services/Firebase";

const Header = ({ onLoginClick }) => {
    const { currentUser } = useContext(AuthContext);
    const navigate = useNavigate();

    const handleSellTicket = () => {
        if (currentUser) {
            navigate("/up-ticket");
        } else {
            navigate("/signup"); // Redirect to signup/login page if not logged in
        }
    };
    const handleLogout = async () => {
        try {
            await auth.signOut();
            navigate("/"); // Redirect to home after logout
        } catch (error) {
            console.error("Error signing out:", error);
        }
    };

    return (
        <header
            className="flex justify-between items-center p-4 fixed w-full z-10"
            style={{
                backgroundImage: 'url("/path/to/your/background-image.jpg")',
                backgroundSize: "cover",
                backgroundPosition: "center",
            }}
        >
            <Link to="/" className="px-6 py-3 text-2xl font-bold text-white">
                MyApp
            </Link>
            <nav className="flex space-x-4">
                <Link
                    to="/tickets"
                    className="px-6 py-3 text-white hover:text-blue-500"
                >
                    Tickets
                </Link>
                {/* Sell Tickets Button */}
                <button
                    className="px-6 py-3 bg-blue-600 text-white rounded hover:bg-blue-700 z-10"
                    onClick={handleSellTicket}
                >
                    Sell Tickets
                </button>
                {currentUser ? (
                    <>
                        <Link
                            to="/profile"
                            className="px-6 py-3 text-white hover:text-blue-500"
                        >
                            Profile
                        </Link>
                        <Link
                            to="/admin"
                            className="px-6 py-3 text-white hover:text-blue-500"
                        >
                            Admin
                        </Link>
                        <button
                            onClick={handleLogout}
                            className="px-6 py-3  bg-red-600 text-white rounded hover:bg-red-700"
                        >
                            Logout
                        </button>
                    </>
                ) : (
                    <>
                        <button
                            onClick={onLoginClick}
                            className="px-6 py-3  bg-blue-600 text-white rounded hover:bg-blue-700"
                        >
                            Login
                        </button>
                        <Link
                            to="/signup"
                            className="px-4 py-2 bg-green-600 text-white rounded hover:bg-green-700"
                        >
                            Sign Up
                        </Link>
                    </>
                )}
            </nav>
        </header>
    );
};

export default Header;
