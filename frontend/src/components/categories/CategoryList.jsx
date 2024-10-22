import React from "react";
import { Link } from "react-router-dom";

const CategoryList = ({ categories }) => {
    return (
        <div className="overflow-x-auto">
            <table className="min-w-full bg-white shadow-md rounded-lg overflow-hidden">
                <thead className="bg-gray-200">
                    <tr>
                        <th className="py-3 px-6 text-left">ID</th>
                        <th className="py-3 px-6 text-left">Name</th>
                        <th className="py-3 px-6 text-left">Description</th>
                        <th className="py-3 px-6 text-left">Actions</th>
                        {/* Add more columns as needed */}
                    </tr>
                </thead>
                <tbody>
                    {categories.map((category) => (
                        <tr
                            key={category.CategoryId}
                            className="border-b hover:bg-gray-100"
                        >
                            <td className="py-4 px-6">{category.CategoryId}</td>
                            <td className="py-4 px-6">{category.Name}</td>
                            <td className="py-4 px-6">
                                {category.Description || "N/A"}
                            </td>
                            <td className="py-4 px-6">
                                <Link
                                    to={`/categories/${category.CategoryId}`}
                                    className="text-blue-500 hover:underline"
                                >
                                    View
                                </Link>
                                {/* Bạn có thể thêm các hành động khác như Edit, Delete */}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default CategoryList;
