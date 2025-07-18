import shutil
import sys
import os
import zipfile


def zip(src, dst):
    zf = zipfile.ZipFile("%s" % (dst), "w", zipfile.ZIP_DEFLATED,allowZip64 = True)
    abs_src = os.path.abspath(src)
    for dirname, subdirs, files in os.walk(src):
        for filename in files:
            absname = os.path.abspath(os.path.join(dirname, filename))
            arcname = absname[len(abs_src) + 1:]
            print('Writing '+filename+' To '+dst)
            zf.write(absname, arcname)
            if args.__contains__("-d"):
                print("Removing "+filename)
                os.remove(absname)
    zf.close()

print("SilicaAndPina's PSV Unity Tools:")
print("-i Input Path")
print("-o Output Path")
print("-f Fix Unsafe Homebrew Bug")
print("-u Remove \"Trial Version\" Watermark")
print("-r Remove unused files")
print("-p Pack to VPK")
print("-d Remove input folder after packing to vpk.")
print("\nExample: UnityTools -i input -o output -f -u -r -p -d")

args = sys.argv[1:]

if len(args) == 1 and os.path.exists(args[0]):
    args = ["-i",args[0],"-o",args[0],"-f","-u","-r","-p","-d"]

if args.__contains__("-i"):
    global inputFolder
    inputFolder = args[args.index("-i") + 1]
else:
    print("No input folder!")
    sys.exit(123)

if args.__contains__("-o"):
    global outputFolder
    outputFolder = args[args.index("-o") + 1]
else:
    print("No output folder! using "+inputFolder+"../out")
    outputFolder = inputFolder+"-out"

print("BEGIN PROCESSING")
print("Looking for SELFs in "+inputFolder)


a = 0

list = os.listdir(inputFolder)
while a != len(list):
    if list[a].lower().endswith(".self") or list[a].lower() == "eboot.bin":
        print("SELF Found: "+list[a])
        global selfFile
        selfFile = list[a]
        a = len(list)
        break
        file.close()
    a += 1
try:
    selfFile
except:
    print("No SELF found! (Incorrect input dir?)")
    sys.exit(643)

if args.__contains__("-f"):
    print("Fixing Unsafe Homebrew bug. . .")
    try:
        with open(inputFolder+"\\"+selfFile,"r+b") as file:
            file.seek(0x80)
            file.write(b"\x00")
            file.close()
    except:
        print("Failed to open SELF: "+selfFile)
        sys.exit(344)
    print("Fixed!")

if args.__contains__("-u"):
    print("Removing \"Trial Version\" Watermark. . .")
    try:
        with open(inputFolder+"\\"+selfFile,"rb") as file:
            readData = file.read()
            offset = readData.index(b"\x74\x72\x69\x61\x6C\x2E\x70\x6E\x67")
            file.close()
        if not readData.__contains__(b"girldying"):
            with open(inputFolder+"\\"+selfFile,"r+b") as file:
                file.seek(offset)
                file.write(b"girldying")
    except:
        print("Failed to open SELF: "+selfFile)
        sys.exit(344)
    print("Watermark Removed.")

if args.__contains__("-r"):
    print("Removing unused files. . .")
    print("Removing SymbolFiles/")
    try:
        shutil.rmtree(inputFolder+"\\SymbolFiles")
    except:
        pass

    print("Removing Configuration.psp2path")
    try:
        os.remove(inputFolder+"\\configuration.psp2path")
    except:
        pass

    print("Removing ScriptLayoutHashes.txt")
    try:
        os.remove(inputFolder+"\\ScriptLayoutHashes.txt")
    except:
        pass

    print("Finding and Removing .bat files. . .")

    try:
        list = os.listdir(inputFolder)
        a = 0
        while a != len(list):
            if list[a].lower().endswith("bat"):
                print("Removing "+list[a])
                os.remove(inputFolder+"\\"+list[a])
            a += 1
    except:
        pass
    print("Removed unused files . . .")

if args.__contains__("-p"):
        print("Packing to .VPK. . .")
        print("Renaming " +selfFile+" To eboot.bin")
        os.rename(inputFolder+"\\"+selfFile,inputFolder+"\\eboot.bin")
        print("Zipping "+inputFolder)
        try:
            os.makedirs(outputFolder)
        except:
            pass
        zip(inputFolder,outputFolder+".vpk")
        if args.__contains__("-d"):
            try:
                print("Removing "+inputFolder)
                shutil.rmtree(inputFolder)
            except:
                pass



