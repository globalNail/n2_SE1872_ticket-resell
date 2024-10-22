import axios from "axios";

const axiosClient = axios.create({
    baseURL: import.meta.env.VITE_API_URL,
    headers: {
        "Content-Type": "application/json",
    },
});

// Interceptor để thêm token vào header nếu có
axiosClient.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem("token"); // hoặc nơi bạn lưu trữ token
        if (token) {
            config.headers["Authorization"] = `Bearer ${token}`;
        }
        return config;
    },
    (error) => Promise.reject(error)
);

export default axiosClient;
