SRGS Grammar Converter
======================

Converts grammars and data files of the [GPSR Command Generator](http://github.com/kyordhel/GPSRCmdGen.git) of the RoboCup @Home League into xml grammar files following the *Speech Recognition Grammar Specification* version 1.0

If you want to compile from source on Ubuntu:

    sudo apt-get install mono-complete
    git clone https://github.com/BioRoboticsUNAM/SRGSConverter.git
    cd SRGSConverter
    make
    
For testing it use
    make run
or
    mono bin/Release/SRGSConverter.exe
After completition, xml srgs grammar files may be found in the srgs subdirectory.

RoboCup@Home teams and team members are welcome to post GitHub issues for clarifications, questions and also contribute with the project etc.
