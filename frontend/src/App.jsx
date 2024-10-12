// src/App.jsx
import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { AuthProvider } from "./contexts/AuthContext";
import Header from "./components/common/Header";

import Home from "./pages/Home";
import StaffApproval from "./pages/verify/StaffApproval";
import TicketList from "./components/ticket/TicketList";
import TicketDetails from "./pages/TicketDetails";
import LoginModal from "./components/LoginModal";
import Modal from "./components/common/Modal";
import Signup from "./pages/Signup";
import Profile from "./pages/Profile";
import AdminDashboard from "./pages/admin/AdminDashboard";
import NotFound from "./pages/error/NotFound";
import ProtectedRoute from "./components/ProtectedRoute";
import UpTicket from "./pages/UpTicket";
import Login from "./pages/login/Login";  // Import Login page

function App() {
    const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);

    const openLoginModal = () => setIsLoginModalOpen(true);
    const closeLoginModal = () => setIsLoginModalOpen(false);

    return (
        <Router>
            <AuthProvider>
                <div className="flex flex-col min-h-screen">
                    {/* Header Component */}
                    <Header onLoginClick={openLoginModal} />

                    {/* Main Content */}
                    <main className="flex-grow">
                        <Routes>
                            <Route path="/" element={<Home />} />
                            <Route path="/tickets" element={<TicketList />} />
                            <Route path="/tickets/:id" element={<TicketDetails />} />
                            <Route path="/signup" element={<Signup />} />
                            <Route path="/login" element={<Login />} />  {/* Define Login route */}
                            <Route path="/profile" element={<Profile />} />

                            {/* Use ProtectedRoute for UpTicket */}
                            <Route
                                path="/up-ticket"
                                element={
                                    <ProtectedRoute>
                                        <UpTicket />
                                    </ProtectedRoute>
                                }
                            />

                            <Route path="/staff-approval" Component={StaffApproval} />
                            <Route
                                path="/admin"
                                element={
                                    <ProtectedRoute>
                                        <AdminDashboard />
                                    </ProtectedRoute>
                                }
                            />

                            {/* Fallback Route */}
                            <Route path="*" element={<NotFound />} />
                        </Routes>
                    </main>

                    {/* Login Modal */}
                    <Modal isOpen={isLoginModalOpen} onClose={closeLoginModal}>
                        <LoginModal onClose={closeLoginModal} />
                    </Modal>
                </div>
            </AuthProvider>
        </Router>
    );
}

export default App;
