
Pipelines - specify the steps that need to run to get the result you want

www.travis.com

Additional Tools

Check out the following links for more information:

    https://arp242.net/diy.html 

    https://help.github.com/en/articles/closing-issues-using-keywords

    https://help.github.com/en/articles/setting-guidelines-for-repository-contributors 

    https://www.infoworld.com/article/3271126/what-is-cicd-continuous-integration-and-continuous-delivery-explained.html

    https://stackify.com/what-is-cicd-whats-important-and-how-to-get-it-right/

    https://docs.travis-ci.com/user/tutorial/

    https://docs.travis-ci.com/user/build-stages/


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

git log --graph --oneline

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

`git merge even-better-feature` - merge the branch into the master brach

if there is a conflict:

`git status` - check the merge status

open a conflicting file and fix it

`git add thefile`

lastly

`git commit` one more time


git merge --abort #will cancell a merge


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
HEAD is an alias to represetn the currently checked-out snapshot of your project

why git commit id is a hash - "You can verify the data you get back out is the exact same data you put in"

https://git-scm.com/docs

links to check
https://git.kernel.org/pub/scm/linux/kernel/git/torvalds/linux.git/tree/Documentation/process/submitting-patches.rst?id=HEAD

http://stopwritingramblingcommitmessages.com/

https://thoughtbot.com/blog/5-useful-tips-for-a-better-commit-message


git rebase -i HEAD~3 # squash last 3 commits


