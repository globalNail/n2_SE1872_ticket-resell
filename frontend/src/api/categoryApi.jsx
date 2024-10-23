// src/api/categoryApi.js
import axiosClient from "./axiosClient";

const categoryApi = {
    getAllCategories: () => {
        const url = "/Category";
        return axiosClient.get(url);
    },
    getCategoryById: (id) => {
        const url = `/Category/${id}`;
        return axiosClient.get(url);
    },
    createCategory: (categoryData) => {
        const url = "/Category";
        return axiosClient.post(url, categoryData);
    },
    // Thêm các phương thức khác nếu cần
};

export default categoryApi;
