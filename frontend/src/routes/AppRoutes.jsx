// src/routes/AppRoutes.jsx
import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import MainLayout from "../layouts/MainLayout";
import TicketsPage from "../pages/Tickets/TicketsPage";
import UploadTicketPage from "../pages/Tickets/UploadTicketPage";
import ViewTicketPage from "../pages/Tickets/ViewTicketPage";
import CategoryListPage from "../pages/categories/CategoryListPage";
import ViewCategoryPage from "../pages/categories/ViewCategoryPage";
// Import các trang khác nếu có

const AppRoutes = () => {
    return (
        <Routes>
            {/* Layout Routes */}
            <Route path="/" element={<MainLayout />}>
                {/* Default Route */}
                <Route index element={<TicketsPage />} />

                {/* Tickets Routes */}
                <Route path="tickets">
                    <Route index element={<TicketsPage />} />
                    <Route path="upload" element={<UploadTicketPage />} />
                    <Route path=":id" element={<ViewTicketPage />} />
                </Route>

                {/* Categories Routes */}
                <Route path="categories">
                    <Route index element={<CategoryListPage />} />
                    <Route path=":id" element={<ViewCategoryPage />} />
                </Route>

                {/* Redirect Unknown Routes to Home */}
                <Route path="*" element={<Navigate to="/" replace />} />
            </Route>
        </Routes>
    );
};

export default AppRoutes;
