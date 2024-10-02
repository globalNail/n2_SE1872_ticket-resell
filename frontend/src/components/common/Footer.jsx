import React from "react";

const Footer = () => {
    return (
        <footer className="bg-gray-800 text-white p-4">
            <div className="container mx-auto text-center">
                &copy; {new Date().getFullYear()} TicketResell. All rights
                reserved.
            </div>
        </footer>
    );
};

export default Footer;
