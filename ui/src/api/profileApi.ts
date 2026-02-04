/* eslint-disable @typescript-eslint/no-explicit-any */
import { fetchFromApi } from "./fetchFromApi";

export const profileApi = {
  get: async (userId: string) =>
    fetchFromApi(`/Profile/${userId}`, {
      method: "GET",
    }),

  create: async (request: any) =>
    fetchFromApi("/Profile", {
      method: "POST",
      body: JSON.stringify(request),
    }),
};
