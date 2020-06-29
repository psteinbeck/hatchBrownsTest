using System;
using System.Drawing.Image;

namespace hatchBrowns
{
    class ImageProcessor
    {
        public static void Main()
        {
            FetchImage();
        }
        private void FetchImage()
        {
            // Create two images.
            Image image1 = Image.FromFile("/Users/SirCharles/HatchBrownsTestRepo/gradient.jpg");
        }
    }
}








/* -----------------------------------------------------------------
% MATLAB CODE 
% Image processing test
% 6/28/2020

close all; clear all;

% Read photo from file
path = 'C:\Users\alemus\Desktop\';
file = 'park.jpg';
name = 'park';
ext = '.jpg';
I = imread(file);

% If photo is too large, resize
ratio = 512 / max(size(I,1),size(I,2));
if ratio < 1
    I = imresize(I,[size(I,1)*ratio, size(I,2)*ratio]);
end

% Break photo up into RGB, then YUV (Just Y)
R = I(:,:,1); G = I(:,:,2); B = I(:,:,3);
Y = R.*.299 + G.*.587 + B.*.114;

% Uniform Dynamic Range applied to new matrix Ynew
pdes = ones(1,256).*floor(numel(Y)/256);
p = zeros(1,256); P = p; Pdes = p;
for x = 1:1:256
    p(x) = sum(sum(Y == x));
    P(x) = sum(p);
    Pdes(x) = sum(pdes(1:x));
end
Ynew = Y;
for x = 1:1:256
    [minValue, closestIndex] = min(abs(P(x) - Pdes.'));
    Ynew(Y == x) = closestIndex;
end


% Use 6 level pattern gradient on Y matrix (grayscale) of image
% Convert to RGB image
INV = levelUp(Y,6);
Rnew = (INV == 0).*256; Bnew = (INV == 0).*256; Gnew = (INV == 0).*256;
Inew = cat(3,Rnew,Gnew,Bnew);

% Repeat with Ynew matrix, which has uniform dynamic range
INV2 = levelUp(Ynew,6);
Rnew = (INV2 == 0).*256; Bnew = (INV2 == 0).*256; Gnew = (INV2 == 0).*256;
Inew2 = cat(3,Rnew,Gnew,Bnew);


% Save in image files
hbfile = strcat(path,name,'_hb.',ext);
hbdrfile = strcat(path,name,'_hb_dr.',ext);
imwrite(Inew, hbfile,'JPEG');
imwrite(Inew2, hbdrfile,'JPEG');

% ------ Functions ------
% Creates pattern with diagonal lines
function matrixOut = diagOut(template, space)
    matrixOut = (zeros(size(template)));
    modded = mod(1:size(matrixOut,2),space)+1;
    for i = 1:size(matrixOut,2)
        matrixOut(modded(i):space:end, i) = 1;
    end
end

% Evenly distributes 'levels' across 0-256 gradient
% Each 'level' is assigned a pattern
% All levels are combined in final matrix
function matrixOut = levelUp(template, levels)
    matrixOut = template <= floor(256/(levels+2)) * (1 ) ;
    for i = 1:levels
        min = floor(256/(levels+2)) * (i   );
        max = floor(256/(levels+2)) * (i+1 );
        LEV = template > min & template <= max;
        MAT_TEMP = PatternSelect(LEV,template,i);
        matrixOut = matrixOut | MAT_TEMP;
    end
end

% Patterns are created and selected based on level
function matrixOut = PatternSelect(matrixIn,template,level)
    PAT = (zeros(size(template)));
    if level == 1
        PAT(1:2:end, :) = 1;
        PAT(:, 1:2:end) = 1;
    elseif level == 2
        PAT = diagOut(template,2);
    elseif level == 3
        PAT = diagOut(template,3);
    elseif level == 4
        PAT(1:2:end, 1:2:end) = 1;
    elseif level == 5
        PAT = diagOut(template,5);
    elseif level == 6
        PAT(1:3:end, 1:3:end) = 1;
    end
    matrixOut = double(PAT & matrixIn);
end

*/