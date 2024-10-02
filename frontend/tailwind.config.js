module.exports = {
    content: [
        "./index.html",
        "./src/**/*.{js,ts,jsx,tsx}",
        // "./pages/**/*.{js,ts,jsx,tsx,mdx}",
        // "./components/**/*.{js,ts,jsx,tsx,mdx}",
        // "./app/**/*.{js,ts,jsx,tsx,mdx}",
    ],
    theme: {
        extend: {
            colors: {
                primary: "#1DA1F2",
                secondary: "#14171A",
            },
            fontFamily: {
                //     sans: ["Inter", "sans-serif"],

                montserrat: ["Montserrat"],
                lato: ["Lato"],
                garamond: ["Garamond"],
            },
        },
    },
    plugins: [
        // require("@tailwindcss/ui")
    ],
};
