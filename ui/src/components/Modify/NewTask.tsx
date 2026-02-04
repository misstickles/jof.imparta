import { useState } from "react";
import { Button, Stack, TextField, Typography } from "@mui/material";
import styles from "@/app/page.module.css";

interface NewTaskProps {
  onClickNewTask: (title: string, description: string) => void;
}

export const NewTask = ({ onClickNewTask }: NewTaskProps) => {
  const [title, setTitle] = useState<string>("");
  const [desctipion, setDescription] = useState<string>("");

  const handleClickNewTask = () => {
    onClickNewTask(title, desctipion);
  };

  return (
    <Stack direction={"row"} className={styles.center} sx={{ justifyContent: "space-between", width: "100%", pb: 3 }}>
      <Typography variant="body1">New Task:</Typography>
      <TextField
        id="taskTitle"
        label="Task Title"
        variant="outlined"
        size="small"
        required
        onChange={(e) => {
          setTitle(e.target.value);
        }}
        value={title}
      />
      <TextField
        id="taskDescription"
        label="Task Description"
        variant="outlined"
        size="small"
        required
        onChange={(e) => setDescription(e.target.value)}
        value={desctipion}
      />
      <Button onClick={handleClickNewTask}>Create</Button>
    </Stack>
  );
};
