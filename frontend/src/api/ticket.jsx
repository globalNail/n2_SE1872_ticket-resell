import axiosClient from "./axiosClient";

const ticketApi = {
    getAllTickets: () => {
        const url = "/Ticket";
        return axiosClient.get(url);
    },
    getTicketById: (id) => {
        const url = `/Ticket/${id}`;
        return axiosClient.get(url);
    },
    createTicket: (ticketData) => {
        const url = "/Ticket";
        return axiosClient.post(url, ticketData);
    },
    // Các phương thức khác nếu cần
};

export default ticketApi;

