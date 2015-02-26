# Add as a submodule to your project #
```
git submodule add git@bitbucket.org:bitkompagniet/bit.helpers.git Bit.Helpers
git submodule update --init
```

# Pre-build events #

The following structure makes it easy to git ignore `_BitLibs/`, since they are copied on compile.

## Scripts ##
`xcopy "$(ProjectDir)\..\Bit.Helpers\ContentLibs\js\*" "$(ProjectDir)\Scripts\_BitLibs\" /s /e /y`

## CSS ##
`xcopy "$(ProjectDir)\..\Bit.Helpers\ContentLibs\css\*" "$(ProjectDir)\Content\css\_BitLibs\" /s /e /y`