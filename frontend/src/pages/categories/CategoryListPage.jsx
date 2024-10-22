// src/pages/Categories/CategoryListPage.jsx
import React from "react";
import useFetchCategories from "../../hooks/useFetchCategories";
import CategoryList from "../../components/categories/CategoryList";
import { Link } from "react-router-dom";

const CategoryListPage = () => {
    const { categories, loading, error } = useFetchCategories();

    if (loading) {
        return (
            <div className="flex justify-center items-center h-screen">
                <div className="text-xl">Loading categories...</div>
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

    return (
        <div>
            <div className="flex justify-between items-center mb-6">
                <h1 className="text-3xl font-bold">Categories</h1>
                <Link
                    to="/categories/upload" // Nếu bạn có trang upload category
                    className="bg-green-500 text-white py-2 px-4 rounded-md hover:bg-green-600 transition-colors"
                >
                    Add New Category
                </Link>
            </div>
            {categories.length === 0 ? (
                <div className="text-gray-500">No categories available.</div>
            ) : (
                <CategoryList categories={categories} />
            )}
        </div>
    );
};

export default CategoryListPage;
