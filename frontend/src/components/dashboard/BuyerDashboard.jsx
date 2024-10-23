import React from "react";
import Layout from "../common/Layout";

function BuyerDashboard() {
    return (
        <Layout>
            <div className="p-4">
                <h1 className="text-2xl font-bold">Buyer Dashboard</h1>
                <p className="mt-2">Manage your purchases here.</p>
                {/* Thêm các thành phần khác như lịch sử mua vé, đơn hàng đang chờ, v.v. */}
            </div>
        </Layout>
    );
}

export default BuyerDashboard;
