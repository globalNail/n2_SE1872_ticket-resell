import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import categoryApi from "../../api/categoryApi";

const ViewCategoryPage = () => {
    const { id } = useParams();
    const [category, setCategory] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchCategory = async () => {
            try {
                const response = await categoryApi.getCategoryById(id);
                setCategory(response.data);
            } catch (err) {
                setError(
                    err.response?.data?.message || "Error fetching category"
                );
            } finally {
                setLoading(false);
            }
        };

        fetchCategory();
    }, [id]);

    if (loading) {
        return (
            <div className="flex justify-center items-center h-screen">
                <div className="text-xl">Loading category details...</div>
            </div>
        );
    }

    if (error) {
        return (
            <div className="flex justify-center items-center h-screen">
                <div className="text-red-500 text-xl">Error: {error}</div>
            </div>
        );
    }

    if (!category) {
        return (
            <div className="flex justify-center items-center h-screen">
                <div className="text-gray-500 text-xl">Category not found.</div>
            </div>
        );
    }

    return (
        <div className="container mx-auto px-4 py-8">
            <h1 className="text-3xl font-bold mb-6">Category Details</h1>
            <div className="bg-white shadow-md rounded-lg p-6">
                <p>
                    <strong>ID:</strong> {category.CategoryId}
                </p>
                <p>
                    <strong>Name:</strong> {category.Name}
                </p>
                <p>
                    <strong>Description:</strong>{" "}
                    {category.Description || "N/A"}
                </p>
                {/* Hiển thị các thông tin khác nếu cần */}
            </div>
        </div>
    );
};

export default ViewCategoryPage;
