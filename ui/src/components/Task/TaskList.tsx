"use client";

import Typography from "@mui/material/Typography";
import { Loading } from "../Core";
import { Button, Card, CardActions, CardContent, Stack, Tooltip } from "@mui/material";

import DoneIcon from "@mui/icons-material/Done";
import RotateRightIcon from "@mui/icons-material/RotateRight";
import HourglassTopIcon from "@mui/icons-material/HourglassTop";
import QuestionMarkIcon from "@mui/icons-material/QuestionMark";

import { TaskStatus } from "@/types";
import { useFetchTasks } from "@/hooks/useFetchTasks";
import { statusColours } from "@/constants";

interface TaskListProps {
  userId: string;
}

export const TaskList = ({ userId }: TaskListProps) => {
  const { taskList, error, loading } = useFetchTasks(userId);

  if (loading) {
    return <Loading />;
  }

  console.log("list", taskList);

  return (
    <Stack direction={"column"} sx={{ width: "100%" }}>
      {taskList.map((t) => {
        return (
          <Card key={t.id} sx={{ bgcolor: `${statusColours[t.status]}`, mb: 5 }}>
            <CardContent>
              <Stack direction={"row"} sx={{ justifyContent: "space-between" }}>
                <Typography gutterBottom variant="h5" component="div">
                  {t.title}
                </Typography>
                <Typography gutterBottom variant="body1" component="div">
                  <Tooltip title={`Task is ${t.status}`}>{statusIcon(t.status)}</Tooltip>
                </Typography>
              </Stack>
              <Typography variant="body2" sx={{ color: "text.secondary" }}>
                {t.description}
              </Typography>
            </CardContent>
            <CardActions sx={{ bgcolor: "text.secondary", justifyContent: "space-between" }}>
              <Button
                size="small"
                variant="contained"
                sx={{ bgcolor: "#CC0000" }}
                title="DANGER!!  Delete this task (no confirmation)."
              >
                Delete Me
              </Button>
              <Stack direction={"row"} gap={2} sx={{ justifyContent: "flex-end" }}>
                <Button
                  size="small"
                  variant="contained"
                  sx={{ bgcolor: `${statusColours["Pending"]}`, "&.Mui-disabled": { color: "#a1a1a1" } }}
                  disabled={t.status === "Pending"}
                  title="Set this task to Pending"
                >
                  Is Pending
                </Button>
                <Button
                  size="small"
                  variant="contained"
                  sx={{ bgcolor: `${statusColours["In Progress"]}`, "&.Mui-disabled": { color: "#a1a1a1" } }}
                  disabled={t.status === "In Progress"}
                  title="Set this task to In Progress"
                >
                  Is In Progress
                </Button>
                <Button
                  size="small"
                  variant="contained"
                  sx={{ bgcolor: `${statusColours["Completed"]}`, "&.Mui-disabled": { color: "#a1a1a1" } }}
                  disabled={t.status == "Completed"}
                  title="Set this task to Completed"
                >
                  Is Completed
                </Button>
              </Stack>
            </CardActions>
          </Card>
        );
      })}
    </Stack>
  );
};

const statusIcon = (status: TaskStatus) => {
  switch (status.toString()) {
    case "Pending":
      return <HourglassTopIcon />;
    case "In Progress":
      return <RotateRightIcon />;
    case "Completed":
      return <DoneIcon />;
    default:
      return <QuestionMarkIcon />;
  }
};
