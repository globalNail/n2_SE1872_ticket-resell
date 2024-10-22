// src/App.jsx
import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { AuthProvider } from "./contexts/AuthContext";
import Header from "./components/common/Header";
import Home from "./pages/Home";
import StaffApproval from "./pages/verify/StaffApproval";
import LoginModal from "./components/LoginModal";
import Modal from "./components/common/Modal";
import Signup from "./pages/Signup";
import Profile from "./pages/Profile";
import AdminDashboard from "./pages/admin/AdminDashboard";
import NotFound from "./pages/error/NotFound";
import ProtectedRoute from "./components/ProtectedRoute";
import Login from "./pages/login/Login"; // Import Login page
import ViewTicketPage from "./pages/tickets/ViewTicketPage"; // Import TicketListPage
import UploadTicketPage from "./pages/tickets/UploadTicketPage";

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
                    <main className="flex-grow relative">
                        <Routes>
                            <Route path="/" element={<Home />} />
                            <Route
                                path="/tickets"
                                element={<ViewTicketPage />}
                            />
                            <Route path="/signup" element={<Signup />} />
                            <Route path="/login" element={<Login />} />
                            <Route path="/profile" element={<Profile />} />

                            <Route
                                path="/up-ticket"
                                element={
                                    <ProtectedRoute>
                                        <UploadTicketPage />
                                    </ProtectedRoute>
                                }
                            />

                            <Route
                                path="/staff-approval"
                                Component={StaffApproval}
                            />
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
