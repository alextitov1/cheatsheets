[use cases](usecases.md)

# git

## git log

diff -u
patch


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

## git add

```sh
git add -p # review the changes befor stagign them

git commit -a # to stage any changes to tracked files
```

## git rm (Removing)

```sh
git rm filename + git commit

git mv filename
```

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

`git merge even-better-feature` - merge the branch into the master brach

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

about merge and pull requests https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/incorporating-changes-from-a-pull-request/about-pull-request-merges

<br>
More Information on Code Reviews

Check out the following links for more information:

    http://google.github.io/styleguide/

    https://help.github.com/en/articles/about-pull-request-reviews

    https://medium.com/osedea/the-perfect-code-review-process-845e6ba5c31

    https://smartbear.com/learn/code-review/what-is-code-review/

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


git rebase -i HEAD~3 # squash last 3 commits

# Ssh-agent and Keychain

## generate a new ssh key pair

```sh
ssh-keygen -t rsa -b 4096 -C "comment" -f ~/.ssh/id_rsa
# assiminng you will specify a passphrase
```

## add the passphrase to the keychain

```sh
ssh-add --apple-use-keychain ~/.ssh/id_rsa
```

## Configure SSH-agent to always use the keychain

in the `.ssh/config` file add the following

```sh
Host * # ssh client will use the key for all hosts
    UseKeychain yes # this is the important line
    IdentityFile ~/.ssh/id_rsa
```
