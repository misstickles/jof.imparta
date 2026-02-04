"use client";

import { useState } from "react";
import Typography from "@mui/material/Typography";
import { Loading } from "../Core";
import { Alert, Button, Card, CardActions, CardContent, Stack, Tooltip } from "@mui/material";

import DoneIcon from "@mui/icons-material/Done";
import RotateRightIcon from "@mui/icons-material/RotateRight";
import HourglassTopIcon from "@mui/icons-material/HourglassTop";
import QuestionMarkIcon from "@mui/icons-material/QuestionMark";

import { Task, TaskStatus } from "@/types";
import { statusColours } from "@/constants";

import EditIcon from "@mui/icons-material/Edit";

import styles from "@/app/page.module.css";
import { EditTask } from "../Modify";

interface TaskListProps {
  tasks: Task[];
  loading: boolean;
  error: string | null;
  onStatusChange: (taskId: string, status: TaskStatus) => void;
  onUpdateTask: (taskId: string, title: string, description: string) => void;
  onDeleteTask: (taskId: string) => void;
}

export const TaskList = ({ tasks, loading, error, onStatusChange, onUpdateTask, onDeleteTask }: TaskListProps) => {
  const [editTask, setEditTask] = useState<string | null>(null);

  if (loading || !tasks) {
    return <Loading />;
  }

  if (error) {
    return <Alert severity="error">Tasks failed to load. Are the APIs running? {error}</Alert>;
  }

  const handleChangeStatus = (taskId: string, status: TaskStatus) => {
    onStatusChange(taskId, status);
  };

  const handleDeleteTask = (taskId: string) => {
    onDeleteTask(taskId);
  };

  const handleEditTask = (taskId: string, title: string, description: string) => {
    onUpdateTask(taskId, title, description);
    setEditTask(null);
  };

  const onCloseEdit = () => {
    setEditTask(null);
  };

  return (
    <Stack direction={"column"} sx={{ width: "100%" }}>
      {tasks.map((t) => {
        return (
          <Card key={t.id} sx={{ bgcolor: `${statusColours[t.status]}`, mb: 5 }}>
            <CardContent>
              <Stack direction={"row"} sx={{ justifyContent: "space-between" }}>
                <Typography gutterBottom variant="h5" component="div">
                  {t.title}
                </Typography>
                <Stack direction={"row"} className={styles.center}>
                  <Typography gutterBottom variant="body1" component="div">
                    <Button onClick={() => setEditTask(t.id)} title="Edit Task" sx={{ pb: 3 }}>
                      <EditIcon />
                    </Button>
                    <Tooltip title={`Task is ${t.status}`}>{statusIcon(t.status)}</Tooltip>
                  </Typography>
                </Stack>
              </Stack>
              <Typography variant="body1" sx={{ color: "text.secondary" }}>
                {t.description}
              </Typography>
              <Typography variant="body2" sx={{ color: "text.secondary", mt: 2 }}>
                {t.createdDate.toLocaleString()}
              </Typography>
              {editTask && (
                <Stack direction={"row"} sx={{ mt: 5 }}>
                  <EditTask
                    taskId={t.id}
                    title={t.title}
                    description={t.description}
                    onCloseEdit={onCloseEdit}
                    onClickEditTask={handleEditTask}
                  />
                </Stack>
              )}
            </CardContent>
            <CardActions sx={{ bgcolor: "text.secondary", justifyContent: "space-between" }}>
              <Button
                size="small"
                variant="contained"
                sx={{ bgcolor: "#CC0000" }}
                title="DANGER!!  Delete this task (no confirmation)."
                onClick={() => {
                  handleDeleteTask(t.id);
                }}
              >
                Delete Me
              </Button>
              <Stack direction={"row"} gap={2} sx={{ justifyContent: "flex-end" }}>
                {["Pending", "In Progress", "Completed"].map((s) => {
                  return (
                    <Button
                      size="small"
                      variant="contained"
                      sx={{ bgcolor: `${statusColours[s]}`, "&.Mui-disabled": { color: "#a1a1a1" } }}
                      disabled={t.status === s}
                      title={`Set this task to ${s}`}
                      onClick={() => {
                        handleChangeStatus(t.id, s as TaskStatus);
                      }}
                      key={s}
                    >
                      Is {s}
                    </Button>
                  );
                })}
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
