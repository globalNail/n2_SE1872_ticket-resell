import React from "react";
import { Link } from "react-router-dom";

function NotFound() {
    return (
        <div className="flex flex-col items-center justify-center h-full p-6">
            <h1 className="text-6xl font-bold mb-4">404</h1>
            <p className="text-xl mb-6">Page Not Found</p>
            <Link
                to="/"
                className="bg-blue-500 text-white px-6 py-3 rounded hover:bg-blue-600"
            >
                Go to Home
            </Link>
        </div>
    );
}

export default NotFound;
