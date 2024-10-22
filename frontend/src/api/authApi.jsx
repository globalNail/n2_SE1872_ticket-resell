import axiosClient from "./axiosClient";

const authApi = {
    login: async (userNameOrEmail, password) => {
        const url = "/Auth/login";
        return axiosClient.post(url, { userNameOrEmail, password });
    },
    googleLogin: (idToken) => {
        const url = "/Auth/google-login";
        return axiosClient.post(url, { idToken });
    },
    register: (userInfo) => {
        const url = "/Auth/register";
        return axiosClient.post(url, userInfo);
    },
    // Các phương thức khác nếu cần
};

export default authApi;
