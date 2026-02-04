import { statusColours } from "@/constants";
import { Task } from "@/types";
import { Paper, Stack, Typography } from "@mui/material";
import styles from "@/app/page.module.css";

interface TaskStatusCountProps {
  tasks: Task[];
}

export const TaskStatusCount = ({ tasks }: TaskStatusCountProps) => {
  const statuses = [
    {
      name: "Pending",
      items: tasks?.filter((f) => f.status === "Pending") ?? [],
    },
    {
      name: "In Progress",
      items: tasks?.filter((f) => f.status === "In Progress") ?? [],
    },
    {
      name: "Completed",
      items: tasks?.filter((f) => f.status === "Completed") ?? [],
    },
  ];

  return (
    <Stack direction={"row"} gap={2}>
      {statuses.map((s) => {
        return (
          <Paper
            square={false}
            elevation={4}
            sx={{
              bgcolor: `${statusColours[s.name]}`,
              color: "#fff",
              padding: 2,
              mb: 4,
            }}
            className={styles.center}
            key={s.name}
          >
            <Typography variant="h4" component="div">
              {s.items.length}
            </Typography>
            &nbsp; &nbsp;
            <Typography variant="body1" component="div">
              {s.name}
            </Typography>
          </Paper>
        );
      })}
    </Stack>
  );
};
