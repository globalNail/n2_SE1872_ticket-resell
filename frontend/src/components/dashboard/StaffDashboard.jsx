import React from "react";
import Layout from "../common/Layout";

function StaffDashboard() {
    return (
        <Layout>
            <div className="p-4">
                <h1 className="text-2xl font-bold">Staff Dashboard</h1>
                <p className="mt-2">Manage tickets and users.</p>
                {/* Thêm các thành phần khác như quản lý vé, xác minh người bán, v.v. */}
            </div>
        </Layout>
    );
}

export default StaffDashboard;
