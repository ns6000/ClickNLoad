# ClickNLoad

**HOWTO**:

1) Use browser's Inspect on green Click'n Load link element within a web page
2) Copy from "form's opening tag -> onsubmit attribute -> CNLPOP js function's 2nd and 3th parameter along with quotes around them (you can even keep the ',' between them...)
3) run: **clickNLoad '<key_chars>', '<encrypted_links_chars>'**
4) ...profit?

Example of text to copy to the command line parameters (everything between the pair of ###):

```html
...
<form action="" target="hidden"
    onsubmit="CNLPOP('<ignore>', ###'1234567890...key_chars', 'abc/j/xyz...encrypted_links_chars'###, '<ignore>'); return false;"
    class="cnlform" method="post">
...
```
