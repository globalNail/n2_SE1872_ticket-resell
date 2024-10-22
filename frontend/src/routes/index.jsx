import SellerDashboard from "../components/dashboard/SellerDashboard";
import BuyerDashboard from "../components/dashboard/BuyerDashboard";
import StaffDashboard from "../components/dashboard/StaffDashboard";
import Home from "../pages/Home";
import { Route } from "react-router-dom";
export const userRoute = [
    {
        path: "/",
        component: <Home />,
        text: "Home",
    },
    {
        path: "/about",
        component: SellerDashboard,
        text: "About",
    },
    {
        path: "/seller",
        component: SellerDashboard,
        text: "Seller",
        roles: ["seller"],
    },
    {
        path: "/buyer",
        component: BuyerDashboard,
        text: "Seller",
        roles: ["buyer"],
    },
];

export const staffRoute = [
    {
        path: "/staff",
        component: StaffDashboard,
        text: "Staff",
        roles: ["staff"],
    },
];

// {
//     userRoute.map((route, index) => (
//         <Route
//             key={index}
//             path={route.path}
//             element={
//                 <ProtectedRoute
//                     roles={route.roles}
//                     component={route.component}
//                 />
//             }
//         />
//     ));
// }
