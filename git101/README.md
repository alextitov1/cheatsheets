
diff -u
patch

# git
The `.git` directory contains all the changes and their history and the working tree contains the current versions of the files.


git init

git status


git config -l

git log

git log -p [-2] #(p for patche) - shows changes

git log --stat - shows chages stats

git log --graph --oneline [--all]

git log -p origin/master

git show fc1009896cd27f3c223af528e79b8521f1c84a21 - shows commint info

git diff  (= diff -u)
git diff --staged


## adding
git add -p # review the changes befor stagign them

git commit -a # to stage any changes to tracked files

## Removing

git rm filename + git commit

git mv filename

## Undoing

`git checkout "filename"` #it reverts changes to modified files **before they are staged**


`git reset HEAD output.txt` #remove changes from the staging area, opposit to *git add* 


## Ammending Commits

git commit --amend # overwrite the previous commit, avoid amending public commits

## Rollbacks

git revert HEAD # revert most resent commit

git revert "hash .. " # rever any commit

## Branches

`git branch` - list all branches in the repo

`git branch somename` - create a branch, but not swithcing to the branch

`git checkout branchname` - change a branch 

`git branch -d branchname` - delete a branch

`git merch even-better-feature` - merge the branch into the master brach

if there is a conflict:

`git status` - check the merge status

open a conflicting file and fix it

`git add thefile`

lastly

`git commit` one more time


git merge --abort #will cancell a merge


git fetch 

git pull = git fetch + git merge

git remote show origin


git remote [Lists remote repos](https://git-scm.com/docs/git-remote)

git remote -v [List remote repos verbosely](https://git-scm.com/docs/git-remote#Documentation/git-remote.txt--v)

git remote show <name> [Describes a single remote repo](https://git-scm.com/docs/git-remote#Documentation/git-remote.txt-emshowem)

git remote update [Fetches the most up-to-date objects](https://git-scm.com/docs/git-remote#Documentation/git-remote.txt-emupdateem)

git fetch [Downloads specific objects](https://git-scm.com/docs/git-fetch)

git branch -r [Lists remote branches](https://git-scm.com/docs/git-branch#Documentation/git-branch.txt--r); can be combined with other branch arguments to manage remote branches

git push -u origin branchname #create and push a new branch to upstream

<br>

---
git rebase -i HEAD~3 #rebase 3 commits back 

---

Fast-forward merge

Implicit merge

Explicit merge

Squash on merge

---
HEAD is an alias to represetn the currently checked-out snapshot of your project

why git commit id is a hash - "You can verify the data you get back out is the exact same data you put in"

https://git-scm.com/docs

links to check
https://git.kernel.org/pub/scm/linux/kernel/git/torvalds/linux.git/tree/Documentation/process/submitting-patches.rst?id=HEAD

http://stopwritingramblingcommitmessages.com/

https://thoughtbot.com/blog/5-useful-tips-for-a-better-commit-message




