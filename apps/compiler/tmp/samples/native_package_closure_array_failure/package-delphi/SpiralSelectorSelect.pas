unit SpiralSelectorSelect;
{$mode objfpc}{$H+}

interface

uses SpiralTypesCallable;

function select0(flag: Boolean): ClosureValue0;

implementation

function select0(flag: Boolean): ClosureValue0;
var
  selected: ClosureValue0;
  values: Array0;
begin
  values := ArrayCreate0(1, False);
  if flag then begin
    DynamicArraySet0(values, 0, 7);
  end else begin
    DynamicArraySet0(values, 0, 8);
  end;
  DynamicArrayClone0(values);
  if flag then begin
    selected := ClosureValueCreate0(values, 0);
  end else begin
    selected := ClosureValueCreate0(values, 1);
  end;
  DynamicArrayDrop0(values);
  Exit(selected);
end;

end.
