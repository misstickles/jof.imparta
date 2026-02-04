/* eslint-disable @typescript-eslint/no-explicit-any */
const apiUrl = process.env.NEXT_PUBLIC_API_BASE_URL as string;

// inputs based on "fetch"
export const fetchFromApi = async (input: string | URL | Request, init?: RequestInit | undefined) => {
  try {
    const response = await fetch(`${apiUrl}${input}`, {
      ...init,
      headers: { "Content-Type": "application/json" },
    });

    if (!response.ok) {
      throw new Error(`HTTP error: Status ${response.status}`);
    }

    const result = await response.json();

    if (result.hasErrors) {
      throw new Error(`API error: ${result.errors}`);
    }

    return result.result;
  } catch (err: any) {
    throw new Error(`Fetch error: ${err}`);
  }
};
