# remove branch locally and remotely

```sh
#remove local branch
git branch -d feature/revertTempChanges
#remove remote branch
git push origin :feature/revertTempChange
#or git push origin --delete feature/revertTempChanges
#prune
origin
git fetch --prune origin 
```

# restore a file from previous commits

