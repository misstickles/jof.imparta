import { CircularProgress, Stack, Typography } from "@mui/material";
import styles from "@/app/page.module.css";

interface LoadingProps {
  size?: number;
}

export const Loading = ({ size = 50 }: LoadingProps) => {
  return (
    <Stack
      className={styles.center}
      sx={{
        height: 350,
      }}
      gap={(theme) => theme.spacing(4)}
    >
      <CircularProgress enableTrackSlot size={size} />
      <Typography variant="body1">Loading...</Typography>
    </Stack>
  );
};
