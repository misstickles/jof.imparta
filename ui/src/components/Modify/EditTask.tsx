import { useState } from "react";
import { Button, Stack, TextField } from "@mui/material";
import styles from "@/app/page.module.css";

import CloseIcon from "@mui/icons-material/Close";

interface EditTaskProps {
  taskId: string;
  title: string;
  description: string;
  onCloseEdit: () => void;
  onClickEditTask: (taskId: string, title: string, description: string) => void;
}

export const EditTask = ({ taskId, title, description, onCloseEdit, onClickEditTask }: EditTaskProps) => {
  const [newTitle, setNewTitle] = useState<string>(title);
  const [newDescription, setNewDescription] = useState<string>(description);

  return (
    <Stack direction={"row"} className={styles.center} sx={{ justifyContent: "space-between", width: "100%" }}>
      <TextField
        id="taskTitle"
        label="New Task Title"
        variant="outlined"
        size="small"
        required
        onChange={(e) => {
          setNewTitle(e.target.value);
        }}
        value={newTitle}
      />
      <TextField
        id="taskDescription"
        label="New Task Description"
        variant="outlined"
        size="small"
        required
        onChange={(e) => setNewDescription(e.target.value)}
        value={newDescription}
      />
      <div>
        <Button onClick={() => onClickEditTask(taskId, newTitle, newDescription)} variant="contained">
          Update
        </Button>
        <Button onClick={onCloseEdit}>
          <CloseIcon sx={{ color: "red" }} />
        </Button>
      </div>
    </Stack>
  );
};
