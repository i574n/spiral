unit SpiralSelectorSelect;
{$mode objfpc}{$H+}

interface

uses SpiralTypesCallable;

function select0(flag: Boolean): ClosureValue0;

implementation

function select0(flag: Boolean): ClosureValue0;
var
  selected: ClosureValue0;
  name: AnsiString;
begin
  if flag then begin
    name := 'abc';
    selected := ClosureValueCreate0(name, 0);
  end else begin
    name := 'wxyz';
    selected := ClosureValueCreate0(name, 1);
  end;
  Exit(selected);
end;

end.
