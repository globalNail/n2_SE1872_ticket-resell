import React, { useContext } from "react";
import { AuthContext } from "../../contexts/AuthContext";
import { Link, useNavigate } from "react-router-dom";
import { auth } from "../../services/Firebase";

const Header = ({ onLoginClick }) => {
    const { currentUser } = useContext(AuthContext);
    const navigate = useNavigate();

    const handleLogout = async () => {
        try {
            await auth.signOut();
            navigate("/"); // Redirect to home after logout
        } catch (error) {
            console.error("Error signing out:", error);
            // Optionally, display an error message to the user
        }
    };

    return (
        <header className="flex justify-between items-center p-4 bg-white shadow">
            <Link to="/" className="text-2xl font-bold">
                MyApp
            </Link>
            <nav className="flex space-x-4">
                <Link
                    to="/tickets"
                    className="text-gray-700 hover:text-blue-500"
                >
                    Tickets
                </Link>
                {currentUser ? (
                    <>
                        <Link
                            to="/profile"
                            className="text-gray-700 hover:text-blue-500"
                        >
                            Profile
                        </Link>
                        <Link
                            to="/admin"
                            className="text-gray-700 hover:text-blue-500"
                        >
                            Admin
                        </Link>
                        <button
                            onClick={handleLogout}
                            className="px-4 py-2 bg-red-600 text-white rounded hover:bg-red-700"
                        >
                            Logout
                        </button>
                    </>
                ) : (
                    <>
                        <button
                            onClick={onLoginClick}
                            className="px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700"
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
