// src/pages/error/Unauthorized.jsx
import React from "react";

function Unauthorized() {
    return (
        <div className="text-center mt-10">
            <h1 className="text-4xl font-bold">
                403 - Không có quyền truy cập
            </h1>
            <p className="mt-4">Bạn không có quyền truy cập vào trang này.</p>
        </div>
    );
}

export default Unauthorized;
