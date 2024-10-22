import { useState, useEffect } from "react";
import categoryApi from "../api/categoryApi";

const useFetchCategories = () => {
const [categories, setCategories] = useState([]);
    const [loadingCategories, setLoadingCategories] = useState(true);
    const [errorCategories, setErrorCategories] = useState(null);

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const response = await categoryApi.getAllCategories();
                setCategories(response.data);
            } catch (err) {
                setErrorCategories(
                    err.response?.data?.message || "Error fetching categories"
                );
            } finally {
                setLoadingCategories(false);
            }
        };

        fetchCategories();
    }, []);

    return { categories, loadingCategories, errorCategories };
};

export default useFetchCategories;
